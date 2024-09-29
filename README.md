# HackYeah - One Paragraph
One Paragraph is a service designed to fetch and provide concise market news summaries to users via a mobile app.

Presentation: https://docs.google.com/presentation/d/1gMfPc1BGj1o_IwfHMIEVOLpt06fU7AOcCv2eZMVtMiI/edit?usp=sharing

# How to access One Paragraph?
Mobile App: <br />
Web Application: <br />
API: https://app-dev-oneparagraph-hqf2erhmhddufnb7.westeurope-01.azurewebsites.net/swagger/index.html <br />
Function App: https://func-dev-oneparagraph.azurewebsites.net <br />

# Architecture As-Is
The current architecture follows a modular approach:
- Function App pulls in the news from an external provider.
- Database stores news summaries from different categories, news about specific stocks, and other necessary data to analyze news with the context of past events.
- Mobile App interacts with the API to display news to users and notify them about the latest market updates.
![Screenshot 2024-09-29 082526](https://github.com/user-attachments/assets/8c125dab-ac83-4c4d-9a6c-ffb363b04926)

# Architecture To-Be
Our desired architecture:
- Function App pulls the news from multiple external providers through API Management.
- API Management is responsible for managing the API access from a unified and centrally visible platform.
- Database stores news summaries from different categories, news about specific stocks, and other necessary data to analyze news with the context of past events.
- Mobile App interacts with the API to display news to users and notify them about market updates.
![Screenshot 2024-09-29 082354](https://github.com/user-attachments/assets/90881933-6c53-417b-b5ee-2e19f405721b)

# How to run it locally?
Please read [How to access One Paragraph?](#how-to-access-one-paragraph) first.
## Requirements:
- Visual Studio 2022 with Azure Development and ASP.NET and web development extensions
- .NET 8

## Api key:
Function App User Secrets: <br />
````
{
	"MarketauxApiBaseUrl": "https://api.marketaux.com/v1/news/all",
	"MarketauxApiKey": "API Key for api.marketaux.com",
	"MarketauxApiKeyStock": "API Key for api.marketaux.com v2",
	"DatabaseConnectionString": "Connection string to MariaDB with the database name: oneparagraph",
	"OpenApiKey": "Key to OpenApi from Azure AI Platform",
	"OpenApiUrl": "OpenApi URL from Azure AI Platform"
}
````
API User Secrets: <br />
````
{
	"DbConnectionString": "Connection string to MariaDB with the database name: oneparagraph"
}
````

## Steps:
- Clone this repository.
- Add User Secrets
- Run either the Function app or API with Visual Studio 2022

# Current State:
- The Category tab is fully functional.
- The Stock tab is partially done. We have all the required data in the backend (deserialized data from the news provider and summarized paragraphs).
- The Trending tab can be done at any time. Requires paid news API subscription.
