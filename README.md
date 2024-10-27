# Coding Challenge - Scratch card promotion

This is an example solution based on the following coding challenge:

> ## Case Back-end Developer
> A website needs to be developed where visitors see a huge
> surprise calendar with 10000 scratchable areas. In one area there is the main prize of 25000 euros.
> There are 100 consolation prizes hidden. A visitor of the website can only scratch open one area.
> They can see which squares have already been opened by other users.
> In the programming language and framework of your choice:
> Create a web page that holds the surprise calendar. It does not need to have any styling. It can be
> an unstyled grid of 100x100 squares. If a user clicks on a cell he will see whether he has won something
> When reloading the page, state must be preserved
> There is no need to build an authentication mechanism, so you can simply simulate multiple users
> using the website.


The solution exposes an API allowing a webpage to retrieve all scratch cards and whether they have already been scratched by other users.

This solution is scaffolded based on the AWS Lambda ASP.NET Core Web API template, found on the Amazon.Lambda.Templates namespace.
The dataset is imported into an EF core InMemory database.

### Public API ###

The API is available publicly at the following URL:
https://ntkdnan81b.execute-api.us-east-1.amazonaws.com/Prod/api/scratchcard/1
The number at the end can be changed to anything, it signifies possible promotion ids

### Running Locally ###

1. In your terminal window, browse to src\LottoChallenge.Promo.Scratch.Api directory.
2. Execute "dotnet run"
3. You can then open a browser and point to the LottoChallenge.Promo.Scratch.UI\index.html file.


### AWS CloudFormation Deployment ###
The cloudformation template can be found at src\LottoChallenge.Promo.Scratch.Api\template.yaml
By installing AWS toolkit for either Visual Studio or Rider, you can right click this file and deploy with your setup credentials.

