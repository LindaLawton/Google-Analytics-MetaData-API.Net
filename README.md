Google Analtyics MetaDATA API .Net
=================================

Sample project for working with the Google Analytics MetaData API in C# .net

This is a simple console application:

The menu allows for the following:

List          -  Lists all Dimensions and metrics

Dimensions    - list all Dimensions

metrics       - List all metrics

Groups        - Distinct list of groups



SETUP
=================================
You will need to create your own credentials in the Google Apis console for it to work:
Go to :  https://console.developers.google.com

Create a new Application:  

APIs & Auth -> APIs Enable Google Analytics API

APIs & Auth -> Credentials -> Create client id for Native application
               it is here you will find the Client id and client secret you will need in order to run the project.
               
APIs & Auth -> Consent screen
                 Be sure to supply an Email Address, and product name. 


Note:  This Project only Selects from the management API.  


Links
=================================

Dimensions & Metrics Reference:           https://developers.google.com/analytics/devguides/reporting/core/dimsmets
What Is The Metadata API - Overview:      https://developers.google.com/analytics/devguides/reporting/metadata/v3/
Google.Apis.Analytics.v3 Client Library:  https://www.nuget.org/packages/Google.Apis.Analytics.v3/