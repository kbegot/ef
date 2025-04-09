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
// Ajout des services pour l'API et Swagger
// ===============================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
