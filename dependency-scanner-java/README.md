# Github Scanner Script

1. Update the **dependency-scanner.properties** to set the username you wish to target and your github token.
2. Run the following commands.

`docker build . -t dependencyscanner`

`docker run -v /home/<username>/.m2/settings.xml:/root/.m2/settings.xml -v /mnt/c/dependencyoutputs:/deps dependencyscanner`

- Returns a list of repositories that it looked at.
- Returns a failed repo list of stuff that maven couldn't parse.

3. Grep the folder or copy to the AWS web server for easier searching. (TBC)

`grep -r -i "<SearchTerm>"  <path> --include="*.txt"`

# ToDo
- Add ability to resume a failure.
- Show maven output on console.
- Can be altered to accept package.json for node deps.