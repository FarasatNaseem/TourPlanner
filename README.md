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
I learned more about unittests and mocking during this project. Other than that, I learned more about asynchronous programming.

#### Mohammad Farhan Saifee:
As a person who had nothing to do with C# 1 year ago, and not even heard of something called WPF, this and the last project (MonsterCardGame) helped me a lot to gather an understanding of how things work with C#. At the TGM we only had JAVA as a programming language and thankfully the syntax of both, Java and C#, are similiar to eacht other. So it wasn't hard to leanr C# and WPF as I thought.\
I also learned about people in general because I often changed the perspective and put myself in the view of someone, who could use this programm. Since then, I'm also more open-minded and think it's better now because I would definitely need that for future projects.


## Design

<img width="428" alt="image" src="https://user-images.githubusercontent.com/46992929/172458106-0476fb38-52f4-4df5-9c71-c9087d2ad2ab.png">

The tour planner application has been splited in to 3 different solution folders.

Client: Basically there are 3 differnt layers in this folder. 
    TourPlanner.PL: This solution just contains views of the application.
    TourPlanner.Client.BL: This solution is used to validate user data, which comes from PL.
    TourPlanner.Client.DL: This solution is used to send data to server, which comes from BL.

Server: Basically there are 3 differnt layers in this folder. 
    TourPlanner.Api: This solution is just a controller, where requests have been arrived.
    TourPlanner.Server.BL: This solution is used to send data to DL.
    TourPlanner.Server.DL: This solution is used to store data into database.

### Design Pattern
#### Singleton pattern
TourPlannerApiServiceProvider is just a provider, who contains instances of service class and it was not necessary to create too many provider objects.

### Programm functionality
User can:
* create, update, delete tours
* create, update, delete tour logs
* generate tour report
* search for tours
* search for tour logs
* export and import tours
* give reviews/feedbacks

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

### Unittests
Solution name: MapQuestApi.Test

Test 1 in class RouteApiServiceTest: GetResponseMustBeTrue_Test()

This test is checked, weather tour distance and time are fetched successfully not

Test 2 in class RouteImageApiServiceTest: GetResponseMustBeTrue_Test()

This test is checked, weather tour image is fetched successfully or not

Reason: Since we are using public api to fetch image, total time and distance, was it necessary
	to test the response.

Solution name: Report.Test

Test 3 in class PdfReportGeneratorTest:  GenerateResponseMustbeTrue_Test()

This test is just checking, weather report is generated successfully or not.

Reason: Since generating is a very important feature of tour planner application
	thats why was it important to create a test.


Solution name: TourPlanner.Client.BL.Test

Test 4 in class TourAuthenticationServiceTest: AuthenticateMustReturnSuccess_Test()

This test is just validating user entered tour data.

Reason: Because it is very important to send correct data to server, thats why was it necessary
	to create a test.

Test 5 in class TourLogAuthenticationServiceTest: AuthenticateMustReturnError_Test()
This test is just validating user entered tour data.
Reason: Because it is very important to send correct data to server, thats why was it necessary
	to create a test.

Test 6 in class ViewModelTest: AddCommand_Test()

This test is just validating, weather command is triggered or not when user click the button.

Reason: It is one of the most important feature, because if a button doesnt work in the application
	then user cant do anything.
 
Test 7 in class ViewModelTest: UpdateViewCommand_Test()

This test is just validating, weather navigation system of the application is working properly or not.

Reason: It is also one of the most important feature, because if navigation system doesnt work properly
	then user cant switch from one view to another view.

Solution name: TourPlanner.Client.DL.Test

Test 8 in class AbstractServiceTest: CreateMustReturnTrue_Test()
Test 9 in class AbstractServiceTest: DeleteMustReturn_True()
Test 10 in class AbstractServiceTest: UpdateMustReturnTrue_Test()
Test 11 in class AbstractServiceTest: ImportMustReturnTrue_Test()
Test 12 in class AbstractServiceTest: ReadAllMustReturn_True()
Test 13 in class AbstractServiceTest: ReadByIdMustReturn_True()
Test 14 in class AbstractServiceTest: ReadListMustReturn_True()

These functions are just validating, weather requests are send to server to properly or not.

Reason: These functions are very important, because if services dont work properly then data will not be send
	to server, thats why these tests were necessary to create.

Solution name: TourPlanner.FileSystem.Test

Test 15 in class JSONFileHandlerTest: ReadShouldBeReturnJSONData_Test()

This function is just checking, weather file data is read properly or not.

Reason: This function plays a very important role in this application and used in different use cases.
	If this function doesnt work properly then tours cant be imported, thats why it was necessary
	 to create a test for it.

Test 16 in class JSONFileHandlerTest: WriteShouldBeReturnJSONData_Test()

This function is just checking, weather data is written in file properly or not.

Reason: This function also plays a very important role in this application and used in different use cases.
	If this function doesnt work properly then tours cant be exported, thats why it was necessary 
	to create a test for it.


Solution name: TourPlanner.Server.DL.Test

Test 17 in class DatabaseTest: DeleteTourByIdMustReturnTrue_Test()
Test 18 in class DatabaseTest: StoreBackupMustReturnTrue_Test()
Test 19 in class DatabaseTest: GetAllTourWithLogsMustReturnTours_Test()
Test 20 in class DatabaseTest: FilterToursMustNotReturnNull_Test()

These functions are just validating, weather CRUD functions are working properly in database or not.

Reason: Again, these functions are very important, if these functions dont work properly then data 
	cant be stored in database, thats why was it necessary to create these tests.

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

