# SurveyBuilder

_ Functionality _

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


_TODOs / What I would have done different_

I'm a bit pressed for time with both work and school, but here are my thoughts:

* Write additional tests: server-side, client-side, and end-to-end (Protractor)
* Implement repository pattern
* Implement service layer
* Utilize data binding models for API controllers (mapping to and from entities using AutoMapper)
* Re-think some of the DB structure -- not terribly comfortable with how EF treats composition/aggregation/etc so I'd need to look into that more.
* Rename the home controller / break up the methods inside it
* Consider using static HTML for Angular views (less overhear than MVC razor views)
* Add UI to show / summarize survey results