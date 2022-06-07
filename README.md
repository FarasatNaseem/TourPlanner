# TourPlanner

The aim of this project is to develop an application based on the GUI framework C# / WPF.
A user is able to create (bike-, hike-, running- or vacation-) tours in advance and manages the logs and statistical data of accomplished tours.

## Failures

### 1 WPF
Because I, M. Farhan Saifee, wasn't familiar with WPF at all at the beginning, it wasn't necessarly hard, but it took a lot of time to learn about it.
And while implementing the navigation between the views there were some complications.

### 2 Layering
We had quite a few problems about the layering part of this project, which held us back a little bit.
There were mostly problems with the communication between database and the 3 layers. It was very hard at first and it took time to solve it.

### 3 Unittests



## Lessons Learned



## Design
First of all we created 3 separate folders: Client, Server & Shared.
The server folder contains the bonus feature, which we will explain more in detail later on.
The client folder contains

### Design Pattern
Singleton pattern

### Programm functionality
User can create Tours
If there a re Tours in the DB already, they will be loaded
If name of Tour already exists then a new tour with the same name cant be added

User can search for Tours and in Tours selbst

export -> remove all Tours -> Import -> Load Tours and there will be all the tours

After creating a tour the data will be also saved in the Tours.json file

Da wir nur 4 städte definiert haben wird bei andern Städten ein Fehler ausgegeben

Unit test: man muss Server laufen lasse damit die paar unit tests funktionieren

### Database

```cs
public (bool, string) AddTour(TourSchemaWithoutLog tourSchema)
        {
            using (IDbConnection connection = this.Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into tour values(@Id, @Name, @TourDescription, @From, @To, @Distance, @TransportType, @RouteImagePath, @EstimatedTime)";
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", this.AutoIncrement("tour")));
                    cmd.Parameters.Add(new NpgsqlParameter("@Name", tourSchema.Name));
                    cmd.Parameters.Add(new NpgsqlParameter("@TourDescription", tourSchema.TourDescription));
                    cmd.Parameters.Add(new NpgsqlParameter("@From", tourSchema.From));
                    cmd.Parameters.Add(new NpgsqlParameter("@To", tourSchema.To));
                    cmd.Parameters.Add(new NpgsqlParameter("@Distance", tourSchema.Distance));
                    cmd.Parameters.Add(new NpgsqlParameter("@TransportType", tourSchema.TransportType.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@RouteImagePath", tourSchema.RouteImage));
                    cmd.Parameters.Add(new NpgsqlParameter("@EstimatedTime", tourSchema.EstimatedTime));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    logger.Log(LogLevel.Information, $"Tour data with name {tourSchema.Name} has been added successfully");
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex.StackTrace);
                    return (false, "Tour cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return (true, "Tour has been added.");
            }
        }
```

### PSQL

### ViewModel

### Unittests

## Bonus Feature
We created the REST-Server as a bonus feature, which is responsible for data management & persistence.
There is a separate folder called server in our project map. In this folder there are 3 subprojects called API, Businesslayer and Datalayer.
The Tourplanner.API project does ...
The Tourplanner.BL project has a class, which executes server operations.
The Tourplanner.DL project contains the database. Other than that, it also has a Tours.json file, which saves all the exisiting tours from the database in JSON-format.

<ADD PICTURE OF SWAGGER HERE>

## Unique Feature
Reviews

## Tracked Time

GUI: 15h\
Tour: 13h\
Tour Logs: 10h\
Database: 20h\
Layering: 27h\
Import/Export: 6h\
Mapquest: 3h\
Mandatory Feature: 5h\
Full-Text Search: 3h\
Protocol: 2h\
Unittests: \
  
Total: 105h


## Github (Link)

https://github.com/FarasatNaseem/TourPlanner

## Abgabe
