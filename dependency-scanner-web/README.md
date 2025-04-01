# Rough and Ready but works
Dependency scanner web - Do not use as source of truth only for advice.

You need to run the dependency scanner and copy the path to the pom folder **(With repo names)** into **POMFOLDER**

> POMFOLDER = List of all dependencies in their folders

> SOURCECODEFOLDER = Path to the .SLN file locally 

> APPFOLDER = Path on host to put the SLN Files


###### [COPY SOURCECODE]
`scp -i ~/.ssh/dependency-scanner-web-live.pem -rp SOURCECODEFOLDER ubuntu@10.74.1.22:/home/ubuntu/APPFOLDER`


###### [[BUILD THE WEBAPP]]
`docker build . -t chdepscanner`

###### [[RUN THE WEBAPP]]
Mount the **/deps** folder on the host to the internal **/app/Deps** on the container.

`docker run -p 8080:80 -v /home/ubuntu/deps:/app/Deps chdepscanner`


###### [COPYDEPS FROM POM]
`scp -i ~/.ssh/dependency-scanner-web-live.pem -rp POMFOLDER ubuntu@10.74.1.22:/home/ubuntu/deps`

##### Developed by Dean Lewis (Innovation Project - dlewis2@companieshouse.gov.uk)