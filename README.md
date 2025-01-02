# Flights

# Commands for local run:
* ```dotnet build```
* ```dotnet ef database update --project ./src/Flights.Api```
* ```dotnet run --project ./src/Flights.Api```


## Docker commands:

### Build an image:
```docker build -t flights-api .```

### Run the container:
```docker run -d -p 8003 flights-api```

## TODOS:

* Add Result Pattern
* Add Database seeding
* Setup Docker Compose