![](https://private-user-images.githubusercontent.com/159132860/303822017-8faf43ca-e920-422f-9546-75f8316d9692.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDc1NDk2OTgsIm5iZiI6MTcwNzU0OTM5OCwicGF0aCI6Ii8xNTkxMzI4NjAvMzAzODIyMDE3LThmYWY0M2NhLWU5MjAtNDIyZi05NTQ2LTc1ZjgzMTZkOTY5Mi5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwMjEwJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDIxMFQwNzE2MzhaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT00MTY3OTJhYTdjZWRiZmIxOTc4OTU2MmIzYWM3MmQwNjkyZjYwMjFlMjVmOTM2MDIxOWNjMDMzYWJmOTY3YThiJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.L-Ln3zNqO-2C_OxhgHQ9RZ0pGOUXck6QTy5a0lygsAQ)

![](https://private-user-images.githubusercontent.com/159132860/303822020-37b569f2-ca16-46a1-ae22-920349a37fb4.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDc1NDk2OTgsIm5iZiI6MTcwNzU0OTM5OCwicGF0aCI6Ii8xNTkxMzI4NjAvMzAzODIyMDIwLTM3YjU2OWYyLWNhMTYtNDZhMS1hZTIyLTkyMDM0OWEzN2ZiNC5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwMjEwJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDIxMFQwNzE2MzhaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1jZTUxZDdiMmQzYTQ3NjBmZDFlYTA0YjA5OWNkOWI3MDI1YzZiZmY2Yjg4NWFkOWFhMGM5ZTgwZWE3YTU3NDRhJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.BWBrBqTkVP5dJavmNWFJd_35yVFjTAk3vng2ex7MOAc)

## How to run

### live action
* https://calculator.albert-ocean.com

### run local
* go to /backend, run 
```
    $ docker build -t backend .      
    $ docker run -d -p 8080:8080 backend
```

* go to /frontend, run 
```
    $ docker build -t backend .      
    $ docker run -d -p 3000:3000 backend
```

* then visit http://localhost:3000

### deployment

Kubernetes files are provided for fast deployments.

Live action of this app is deployed on AWS EKS using kubernetes files in this project.

If you want to deploy yourself, be advised:

* modern browsers require the communication between frontend and backend to use https, you so need to wrap the backend in an aws application load balancer.
* AWS advertises EKS as a managed k8s service, but you still need to install the AWS Load Balancer Controller yourself. 

<br>

## Implementation

<br>

### Backend

        The infamous 0.1 + 0.2 != 0.3 problem

This is a problem of arbitrary-precision calculation. In Java or C/C++, you have scientific libraries for that, but not in C#. Luckily, c# has decimal type which is good enough for most situations including financial calculations thanks to its high precision (26 ~ 27 bits of precision, in comparison, float only guarantees 6 ~ 7 bits of precisions).

        Design

The specs is very specific about the design of endpoints: receiving two numbers and output the result number, and this project did exactly as told. But a better design idea for a calculator would be to evaluate the math expression as a string. There are several popular libraries for this including Matheval. 

        Versioning

This project supports versioning of backend API, as given in the path: api.albert-ocean.com/calculator/api/v2/...

        Testing

Tests are written for controllers, using xUnit framework. Testing is implemented in C# using a standalone project which links to your original test. To run tests, go to /tests folder and run $ dotnet test

        Logging

In this project, logging s implemented using SeriLog framework, with rolling period of one day. Logs are directed to files instead of in console, for the benefits of persistence.

        CORS

All origins are allowed, but of course as a best practice you should only allow the minimum necessary origins. 

        SSL Certificate

ASP.NET offers https connections but I decided to use AWS application load balancer to wrap up the backend because it's easier to work with SSL certificates. SSL cert is provided by AWS ACM for the domain name of albert-ocean.com, which I keep for personal use. 

        Dockerfile

There are two dockerfiles, one for bakcend and one for frontend. They are divided into layers for faster incremental updates.

<br>

### Frontend

This minimalist frontend is for demo purpose.

        Framework

Frontend is implemented using react and material-ui. The page consists of several components.

        Colors

Each you time you refresh the page, colors are randomized using useEffect(). 

        Calculation result

All calculations are performed in backend, including the logic of dividing by zero (should it equal to infinity or be completely prohibited), as required in the spec.

Calculation results update automatically to user inputs, no user-clicking is involved. Tempering with the result is not possible, but you can select and copy results.

<br>

# Compile and run

* for backend, go to /backend, then:

        $ dotnet run

* for frontend, go to /frontend, then:

        $ npm install
        $ npm start