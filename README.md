# COMPLETION CAFE ☕ 🥐 🥯


## Overview
A place to keep record of your accomplishments, in progress or complete. A website written in C# that stores user data to log your tasks and reward you with a cup of coffee or a pastry. 

## Technical Summary

-  **Backend:** C# 
-  **Framework:** ASP.NET Core MVC

## Main Function

- Create new entries: assign them a category, completion status, deadline, description, and notes. 
- Sort your recorded entries by any of their properties to check out what you have upcoming - or look at your previous accomplishments.
- Mark the entries as complete and get the sweet dopamine of a coffee or donut on screen!

## Features

- **Accomplishment class** (MVC model) keeps track of all the properties of your accomplishment entries.
- Accomplishment objects (entries) can be created, edited, and deleted with MVC controller methods. 
- DateTime of page (when loaded) displayed on screen for convenience and urgence. 
- **DateTime matched (regex)** with future entries to show how long you have left to complete the task. (Or show how many days it's been since a past entry.)
- Entries are sortable with the help of a **LINQ query.**
- Store entries **written and read from an SQL database** for ongoing projects.

## Future Implementations

- Fix sort by date functionality
- Add different users
- Host on Herokuapp
- Update site Html/Css
