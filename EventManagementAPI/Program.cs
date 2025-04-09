using System.Reflection;
using System.IO;
using EventManagementAPI.Data;
using EventManagementAPI.Mapping;
using EventManagementAPI.Middlewares;
using EventManagementAPI.Repositories;
using EventManagementAPI.Repositories.Interfaces;
using EventManagementAPI.Services;
using EventManagementAPI.Services.Interfaces;
using EventManagementAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ===============================================
// Configuration de la base de données
// ===============================================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// ===============================================
// Configuration de FluentValidation
// ===============================================
builder.Services.AddValidatorsFromAssemblyContaining<CreateEventDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateLocationDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateParticipantDTOValidator>();
builder.Services.AddFluentValidationAutoValidation();

// ===============================================
// Enregistrement des repositories et services
// ===============================================
// Event
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

// Participant
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();

// Session
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();

// Speaker
builder.Services.AddScoped<ISpeakerRepository, SpeakerRepository>();
builder.Services.AddScoped<ISpeakerService, SpeakerService>();

// Location
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

// Room
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();

// EventParticipant (Inscriptions)
builder.Services.AddScoped<IEventParticipantRepository, EventParticipantRepository>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

// Rating
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();

// SessionSpeaker
builder.Services.AddScoped<ISessionSpeakerRepository, SessionSpeakerRepository>();
builder.Services.AddScoped<ISessionSpeakerService, SessionSpeakerService>();

// ===============================================
// Enregistrement d'AutoMapper
// ===============================================
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ===============================================
// Configuration Swagger (commentary XML)
// ===============================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "API de Gestion d'Événements",
        Description = "Une API REST complète pour la gestion des événements, participants, sessions, intervenants, lieux, salles, inscriptions, notations et associations entre sessions et intervenants.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {}
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// ===============================================
// Ajout des services pour l'API
// ===============================================
builder.Services.AddControllers();

var app = builder.Build();

// ===============================================
// Exécution du Seeding de la base de données
// ===============================================
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DatabaseSeeder.Seed(context);
}

// ===============================================
// Configuration des Middlewares
// ===============================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gestion d'Événements v1");
        options.RoutePrefix = string.Empty; // Swagger root URL
    });
}

// Middleware de gestion des exceptions
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
