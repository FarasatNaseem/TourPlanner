# TourPlanner

The aim of this project is to develop an application based on the GUI framework C# / WPF.
A user is able to create (bike-, hike-, running- or vacation-) tours in advance and manages the logs and statistical data of accomplished tours.

## Failures

## Lessons Learned

## Design
First of all we created 3 separate folders: Client, Server & Shared.
The server folder contains the bonus feature, which we will explain more in detail later on.
The client folder contains

### Database

### PSQL

### ViewModel

### Unittests

## Bonus Feature
We created the REST-Server as a bonus feature, which is responsible for data management & persistence.
There is a separate folder called server in our project map. In this folder there are 3 subprojects called API, Businesslayer and Datalayer.
The Tourplanner.API project does ...
The Tourplanner.BL project has a class, which executes server operations.
The Tourplanner.DL project contains the database. Other than that, it also has a Tours.json file, which saves all the exisiting tours from the database in JSON-format.

## Unique Feature

## Zeitaufzeichnung / Tracked Time

## Github (Link)

## Abgabe
