# Functional Requirements

## Manage Movies:
* The system has to be able to show a list of movies.
* The system has to be able to show each movie independently.
* The system has to be able to process CRUD actions on a movie.

## Authentication
* The system has the ability to authenticate a user using his or her username and password.

## Watch Movies 
* The system has the ability to show the most popular movies in the last two weeks (sorted descending).
* The system has the ability to show the most popular movies ever (sorted descending).
* The system has the ability to show a movie including all its details (cast, genre, directors).
* The system has the ability to show all other movies that belong to the same series.
* The system has the ability to process a search request for a certain movie.
* The system has the ability to show the movie to the customer via a url in a movieplayer.

## Rate Movies
* The system has the ability to show movies that were already watched by the customer.
* The system has the ability to process a rating that was given by the customer (include date).
* The system has the ability to validate ratings (comment must be atleast 10 characters and rating must be between 1 & 10).
* The system has the ability to process a editted rating that was given by the customer (include date).
* The system has the ability to process a request from the customer to remove his or her rating.

## Movie nominations
* The system has the ability to process CRUD operations on the nominations associated with a movie issued by the management.
* The system has the ability to add 0..n nominations per movie.
* The system has the ability to save the folling fields: award, result (iether nominated or won) and amount of nominations.

## Movie Awards
* The system has the ability to filter movies on a period in time (from, until) based on publication year.
* The system has the ability to deal with an empty from or until filter.

## Print rating report
* The system has the ability to print a top 10 movies based on: lowest average rating, highest average rating, rating-price index.
* The system has the ability to ignore movies that have not yet received a rating.

# Non-Functional Requirements

* Hosted on Microsoft Azure Platform.
* Written in Microsoft ASP.Net Core.
* Uses ASP.Net MVC.
* The system must be safe (OWASP top 10)
* The system must me scalable.

