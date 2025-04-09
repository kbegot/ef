
---

# API de Gestion d'Événements

Une API REST complète, construite sur ASP.NET Core et Entity Framework Core, pour gérer des événements professionnels (conférences, salons, workshops, etc.).  
L'API permet la gestion de l'intégralité du cycle de vie des entités suivantes :

- **Événements**
- **Participants**
- **Sessions**
- **Intervenants (Speakers)**
- **Lieux (Locations)**
- **Salles (Rooms)**
- **Inscriptions aux Événements (EventParticipants)**
- **Notations de Sessions (Ratings)**
- **Associations entre Sessions et Intervenants (SessionSpeakers)**

L'application intègre des fonctionnalités avancées telles que le filtrage, la pagination, la validation robuste des données grâce à FluentValidation, le seeding de données initiales et une documentation complète avec Swagger.

---

## Table des Matières

- [Fonctionnalités](#fonctionnalités)
- [Architecture et Technologie](#architecture-et-technologie)
- [Installation et Configuration](#installation-et-configuration)
- [Utilisation de l'API](#utilisation-de-l-api)
  - [Routes Principales](#routes-principales)
  - [Exemples d'Appels API](#exemples-dappels-api)
- [Extensions Possibles](#extensions-possibles)
- [Structure du Projet](#structure-du-projet)

---

## Fonctionnalités

- **CRUD Complète** pour toutes les entités (événements, participants, sessions, intervenants, lieux, salles, inscriptions, notations et associations session-intervenants).
- **Filtrage & Pagination** sur la liste des événements : filtration par date, lieu, catégorie et statut avec retour paginé.
- **Validation Robuste** des données entrantes grâce à FluentValidation pour s'assurer de la cohérence des données (exemple : dates d'événement, format de l'email).
- **Gestion Centralisée des Exceptions** avec un middleware personnalisé pour des réponses d'erreur uniformisées.
- **Seeding Automatique** : La base de données est automatiquement peuplée avec des données cohérentes lors du démarrage.
- **Documentation Interactive** via Swagger UI, permettant de tester et documenter l'API facilement.
- **Architecture en Couches & Respect des Principes SOLID** : Séparation des responsabilités entre Controllers, Services, Repositories et Entities.

---

## Architecture et Technologie

- **Framework** : ASP.NET Core 8
- **ORM** : Entity Framework Core 8
- **Langage** : C#
- **Validation** : FluentValidation.AspNetCore
- **Mapping** : AutoMapper
- **Base de Données** : MySQL (exemple via Docker)
- **Documentation** : Swagger
- **Tests** : Tests unitaires (à implémenter avec Moq, xUnit ou NUnit)

---

## Installation et Configuration

### Prérequis

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- MySQL/MariaDB (ou Docker pour exécuter MySQL/MariaDB)
- Outil de gestion de packages NuGet
- Un éditeur de code (Visual Studio, VS Code, etc.)

### Étapes d'installation

1. **Cloner le Repository**  
   ```bash
   git clone https://github.com/kbegot/ef.git
   cd EventManagementAPI
   ```

2. **Restaurer les Packages NuGet**  
   ```bash
   dotnet restore
   ```

3. **Configurer la Chaîne de Connexion**  
   Dans le fichier `appsettings.json`, mettez à jour la chaîne de connexion pour MySQL :
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;port=3306;database=EventManagementDb;user=root;password=VotreMotDePasse"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
       }
     },
     "AllowedHosts": "*"
   }
   ```

4. **Migrations & Seeding**  
   - Pour créer la base de données et exécuter les migrations :
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```
   - Le seeding est automatiquement appelé lors du démarrage de l'application (voir [Utilisation de l'API](#utilisation-de-l-api)).

5. **Lancer l'Application**  
   ```bash
   dotnet run
   ```

---

## Utilisation de l'API

### Routes Principales

Les contrôleurs exposent des endpoints RESTful pour chaque entité. Voici un aperçu :

- **Événements**
  - `GET /api/Event` : Récupérer tous les événements.
  - `GET /api/Event/{id}` : Récupérer un événement par ID.
  - `POST /api/Event` : Créer un nouvel événement.
  - `PUT /api/Event/{id}` : Mettre à jour un événement.
  - `DELETE /api/Event/{id}` : Supprimer un événement.
  - **Filtrage & Pagination**  
    `GET /api/Event/filter?StartDate=2025-05-01&EndDate=2025-05-31&Location=Paris&Category=Tech&Status=Programmé&page=1&pageSize=10`  

- **Participants**
  - `GET /api/Participant` : Récupérer tous les participants.
  - `GET /api/Participant/{id}` : Récupérer un participant par ID.
  - `POST /api/Participant` : Créer un participant.
  - `PUT /api/Participant/{id}` : Mettre à jour un participant.
  - `DELETE /api/Participant/{id}` : Supprimer un participant.

- **Sessions**
  - `GET /api/Session` : Récupérer toutes les sessions.
  - `GET /api/Session/{id}` : Récupérer une session par ID.
  - `POST /api/Session` : Créer une session.
  - `PUT /api/Session/{id}` : Mettre à jour une session.
  - `DELETE /api/Session/{id}` : Supprimer une session.

- **Intervenants (Speakers)**
  - `GET /api/Speaker` : Récupérer tous les intervenants.
  - `GET /api/Speaker/{id}` : Récupérer un intervenant par ID.
  - `POST /api/Speaker` : Créer un intervenant.
  - `PUT /api/Speaker/{id}` : Mettre à jour un intervenant.
  - `DELETE /api/Speaker/{id}` : Supprimer un intervenant.

- **Lieux (Locations)**
  - `GET /api/Location` : Récupérer toutes les locations.
  - `GET /api/Location/{id}` : Récupérer une location par ID.
  - `POST /api/Location` : Créer une location.
  - `PUT /api/Location/{id}` : Mettre à jour une location.
  - `DELETE /api/Location/{id}` : Supprimer une location.

- **Salles (Rooms)**
  - `GET /api/Room` : Récupérer toutes les salles.
  - `GET /api/Room/{id}` : Récupérer une salle par ID.
  - `POST /api/Room` : Créer une salle.
  - `PUT /api/Room/{id}` : Mettre à jour une salle.
  - `DELETE /api/Room/{id}` : Supprimer une salle.

- **Inscriptions (EventParticipants) / Gestion des Inscriptions**  
  - `POST /api/Registration` : Inscrire un participant à un événement.
  - `DELETE /api/Registration/{eventId}/{participantId}` : Désinscrire un participant.

- **Notations (Ratings)**
  - `GET /api/Rating` : Récupérer toutes les notations.
  - `GET /api/Rating/{id}` : Récupérer une notation par ID.
  - `POST /api/Rating` : Créer une notation.
  - `PUT /api/Rating/{id}` : Mettre à jour une notation.
  - `DELETE /api/Rating/{id}` : Supprimer une notation.

- **Associations Session/Intervenant (SessionSpeakers)**
  - `GET /api/SessionSpeaker` : Récupérer toutes les associations.
  - `GET /api/SessionSpeaker/{sessionId}/{speakerId}` : Récupérer une association spécifique.
  - `POST /api/SessionSpeaker` : Créer une association.
  - `PUT /api/SessionSpeaker/{sessionId}/{speakerId}` : Mettre à jour une association.
  - `DELETE /api/SessionSpeaker/{sessionId}/{speakerId}` : Supprimer une association.

### Exemples d'Appels API

#### Exemple – Filtrage et Pagination (Événements)
**Requête :**
```http
GET /api/Event/filter?StartDate=2025-05-01&EndDate=2025-05-31&Location=Paris&Category=Technologie&Status=Programmé&page=1&pageSize=5 HTTP/1.1
Host: localhost:5000
```
**Réponse :**
```json
{
  "page": 1,
  "pageSize": 5,
  "totalItems": 12,
  "items": [
    {
      "id": 3,
      "title": "Conférence sur l'IA",
      "description": "Discussion sur l'intelligence artificielle",
      "startDate": "2025-05-05T08:00:00Z",
      "endDate": "2025-05-05T17:00:00Z",
      "status": "Programmé",
      "category": "Technologie",
      "locationId": 1,
      "location": {
         "id": 1,
         "name": "Centre de Conférence",
         "address": "123 Rue A",
         "city": "Paris",
         "country": "France",
         "capacity": "500"
      }
    },
    ...
  ]
}
```

#### Exemple – Création d'un Événement
**Requête :**
```http
POST /api/Event HTTP/1.1
Host: localhost:5000
Content-Type: application/json

{
  "title": "Nouvel Événement",
  "description": "Description de l'événement",
  "startDate": "2025-06-10T09:00:00Z",
  "endDate": "2025-06-10T17:00:00Z",
  "status": "Programmé",
  "category": "Innovation",
  "locationId": 1
}
```
**Réponse (HTTP 201 Created) :**
```json
{
  "id": 5,
  "title": "Nouvel Événement",
  "description": "Description de l'événement",
  "startDate": "2025-06-10T09:00:00Z",
  "endDate": "2025-06-10T17:00:00Z",
  "status": "Programmé",
  "category": "Innovation",
  "locationId": 1,
  "location": null
}
```

---

## Structure du Projet

- **Controllers/** : Contient les contrôleurs REST pour chaque entité.
- **DTOs/** : Contient les Data Transfer Objects, y compris ceux pour la pagination et le filtrage.
- **Models/** : Les modèles de données pour l'ORM (EF Core).
- **Repositories/** : Contient les interfaces et implémentations pour l'accès aux données.
- **Services/** : Contient les interfaces et implémentations de la logique métier.
- **Validators/** : Contient les validateurs FluentValidation pour les DTOs.
- **Mapping/** : Contient le MappingProfile pour AutoMapper.
- **Data/** : Contient le DbContext et le seeder pour la base de données.
- **Middlewares/** : Contient le middleware de gestion des exceptions.

