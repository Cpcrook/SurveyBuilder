
# SurveyBuilder Functionality
=============

* Register as a user
* Sign in / out
* Angular bearer-token authentication
* Ability to create a survey with name, description, and message to display on completion
* Ability to add/remove text-based questions to survey
* Ability to add/remove multiple-choice questions to survey (as well as manipulate options)
* Ability to re-order questions in survey via drag-and-drop
* Ability to view surveys created by signed in user and delete them
* Ability to edit existing surveys
* Ability to "preview" or really, take the actual survey


Notes / Deficiencies
==========================================

I'm a bit pressed for time with both work and school, but here's my self-critique:

* Write tests: server-side, client-side, and end-to-end (Protractor)
* Utilize FluentValidation for server-side validation
* Use a framework for client-side validation
* Implement repository pattern
* Re-organize project into projects (UI, DAL containing repositories and EF goodies, BusinessLogic containing validation, Core for anything shared amongst all projs, Services for a service layer to improve abstraction, then test projects for each)
* Dependency Injection (I set up IoC so infrequently on a new project that I felt it wasn't worth the time for this exercise)
* Utilize data binding models for API controllers (mapping to and from entities using AutoMapper)
* Re-think some of the DB structure -- not terribly comfortable with how EF treats composition/aggregation/etc so I'd need to look into that more.
* Rename the home controller / break up the methods inside it
* Consider using static HTML for Angular views (less overhead than MVC razor views)
* Add UI to show / summarize survey results
* Used Git and GitFlow pattern through the (relatively short) process instead of toward ends


Thanks for the opportunity and let me know if you have any questions.
- Chris