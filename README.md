# HackYeah - One Paragraph

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
The current architecture follows a modular approach:
- Function App pulls the news from multiple external providers through API Management.
- API Management is responsible for managing the API access from a unified and centrally visible platform.
- Database stores news summaries from different categories, news about specific stocks, and other necessary data to analyze news with the context of past events.
- Mobile App interacts with the API to display news to users and notify them about market updates.
![Screenshot 2024-09-29 082354](https://github.com/user-attachments/assets/90881933-6c53-417b-b5ee-2e19f405721b)
