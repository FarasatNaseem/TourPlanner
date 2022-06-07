# TourPlanner

The aim of this project is to develop an application based on the GUI framework C# / WPF.
A user is able to create (bike-, hike-, running- or vacation-) tours in advance and manages the logs and statistical data of accomplished tours.\

Here are the exact requirements/specifications of what the program should do and how it should look like: [Tour Planner](/TourPlanner_Specification.pdf)

Our Tourplanner, as of now, looks like this:\
<img width="1200" alt="image" src="https://user-images.githubusercontent.com/46992929/172450247-295e76e6-c01e-4a42-ab62-78cbe1b07586.png">

## Failures

### 1 WPF
Because we weren't familiar with WPF at all at the beginning, it wasn't necessarly hard, but it took a lot of time to learn about it.
And while implementing the navigation between the views there were some complications.

### 2 Layering
We had quite a few problems about the layering part of this project, which held us back a little bit.
There were mostly problems with the communication between database and the 3 layers. It was very hard at first and it took time to solve it.

### 3 Unittests
At first we thought about Unittesting as an easy part of this project compared to other funcionalites, which were given us to do. But it turned out that some Unittests were quite hard to do and it took us very long to think about how to implement them. Here is one Unittest, where we had diffculties:

```cs
[Test]
        public void CreateMustReturnTrue_Test()
        {
            var tourMock = new Mock<Tour>();

            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            var retrievedPosts = AsyncContext.Run(() => this._service.Create(tourMock.Object));

            Assert.IsTrue(retrievedPosts.IsCorrectlyResponded);
        }
        
```

## Lessons Learned

#### Muhammad Farasat Hussein:

#### Mohammad Farhan Saifee:
As a person who had nothing to do with C# 1 year ago, and not even heard of something called WPF, this and the last project (MonsterCardGame) helped me a lot to gather an understanding of how things work with C#. At the TGM we only had JAVA as a programming language and thankfully the syntax of both, Java and C#, are similiar to eacht other. So it wasn't hard to leanr C# and WPF as I thought.\
I also learned about people in general because I often changed the perspective and put myself in the view of someone, who could use this programm. Since then, I'm also more open-minded and think it's better now because I would definitely need that for future projects.


## Design

<img width="428" alt="image" src="https://user-images.githubusercontent.com/46992929/172458106-0476fb38-52f4-4df5-9c71-c9087d2ad2ab.png">


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

#### Use-Case Diagram:
<img width="400" alt="image" src="https://user-images.githubusercontent.com/46992929/172453960-ccf4110a-afe4-4336-804b-0c3e73cc232d.png">


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

### Unittests


Here is an example. This unittest checks whether the data has been stored successfully or not:

```cs

[Test]
        public void StoreBackupMustReturnTrue_Test()
        {
            var tourData = new Mock<List<TourSchemaWithLog>>();

            var response = this._tourPlannerDatabase.StoreBackup(tourData.Object);

            Assert.IsTrue(response.Item1);
        }
```

## Bonus Feature
We created the REST-Server as a bonus feature, which is responsible for data management & persistence.
There is a separate folder called server in our project map. In this folder there are 3 subprojects called API, Businesslayer and Datalayer.
The Tourplanner.API solution is basically the controller.
The Tourplanner.BL solution has a class, which executes server operations.
The Tourplanner.DL solution contains the database. Other than that, it also has a Tours.json file, which saves all the exisiting tours from the database in JSON-format.\
If we run the project the Server also runs and this opens as well:

<img width="928" alt="Server_Review" src="https://user-images.githubusercontent.com/46992929/172460356-6bd4b78d-1955-496d-ba70-ab6464d3b6cb.png">

<img width="930" alt="Server_Tour" src="https://user-images.githubusercontent.com/46992929/172460392-7d5933ef-5297-4cee-85c3-b459f482c639.png">

<img width="926" alt="Server_TourLog" src="https://user-images.githubusercontent.com/46992929/172460419-0b832eba-18c3-45d0-836d-21214b160212.png">



## Unique Feature: Reviews
After we finished the project was almost finished, about 90%, we started to think of the unique feature and decided to do create a "REVIEW" function for users.
It basically means that users can give feedbacks/reviews about this application. This is actually a very important point because we can then add wishes of the users or change anything that the users want to be changed for example.\
In order to give a review, the user can click on the "ADD REVIEW" button and type in their name and the review or feedback they want to give. This will then be saved and after the user goes back to home he or she can click on "REVIEWS" to see the review(s) shown as a list. Here's how it looks like:

<img width="1200" alt="image" src="https://user-images.githubusercontent.com/46992929/172462042-c1d570be-16b3-49b2-9974-baf34bb32903.png">


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
Protocol: 4h\
Unittests: 14h\
  
Total: **120h**


## Github (Link)

https://github.com/FarasatNaseem/TourPlanner

## Abgabe
