from ubuntu:latest

RUN apt-get update
RUN apt-get install -y openjdk-11-jdk maven
RUN mkdir app
WORKDIR app
COPY . .
RUN mvn clean package
RUN mkdir /deps
CMD ["java","-jar","/app/target/app-0.0.1-SNAPSHOT.jar"]