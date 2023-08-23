# Infotrack

I've made a .NET Core Webapi along with a Vue.js SPA frontend. I also added an SQL Express database connection.

## Frontend

To run the frontend, go to Frontend > Infotrack. There is a readme file there, but to summarize: running the commands "npm install" and "npm run dev" in the terminal should make it run.

## Backend

For the backend, open the solution in Visual Studio and run.

## Database

The database uses SQL Express. It might set up on its own when running the backend, but if not migration files can be found in Backend > InfoTrack > Migrations. Use these with the command Update-Database. The database will fill with dummy data when the backend is run. Connection string can be found in Backend > InfoTrack > appsettings.json

---

I would've liked to explore concepts such as N-tier architecture and unit testing for this project, but I can't spend more time on it as my dissertation is due in just a few days
That should cover everything. If you have any issues or questions, please get in touch!
