## InfoTrack Conveyancer API



### Implementation details (Framework, Libraries and architecture)
- .NET 6
- xUnit (Integration Tests)
- Serilog 
- Swagger Docs (swashbuckle)
- EntityFramework Core (InMemory database)
- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Mediator Pattern (using MediatR Library)
- Dependency Injection
- Domain Validation (using FluentValidation Library) and exception handling using pipeline behaviour.


### How to test the API endpoint?
- Run `InfoTrack.Conveyancer.API` project
- You can test it using Swagger Doc (https://localhost:7238/swagger/index.html)
- Or by import the following cURL to postman or run it via terminal:

```bash
curl -X 'POST' \
  'https://localhost:7238/Settlement/booking' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "bookingTime": {
    "hour": 10,
    "minute": 30
  },
  "name": "Matt"
}'
```