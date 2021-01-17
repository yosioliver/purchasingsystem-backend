# purchasingsystem-backend

This is the Repository for the Backend Stack for The Phone Balance Purchasing System.

# Requierements

For Database :
  - PostgreSQL 11 (PostgreSQL 10 will be ok)
  - you can install here : [Download PostgreSQL](https://www.postgresql.org/download/)
  - Or, if you using MacOS Machine you can install brew here : [Download Brew](https://brew.sh)
  - After brew installed on your MacOS Machine, type the command below for installing PostgreSQL 11 :

```sh
$ brew install postgresql@11
```
Setup your Database :
  - You can use DBeaver for Administering your PostgreSQL Database
  - You can install DBeaver here : [Download DBeaver](https://dbeaver.io/download/)
  - After installing DBeaver, you can setup the Database (please see images below for the instruction)

![Postgre](https://i.ibb.co/vwz9Xns/Screen-Shot-2021-01-17-at-19-27-58.png)

On the image above, Select PostgreSQL for your Database Connection, after that you can fill the information like the image below : 

![Postgre](https://i.ibb.co/F8jhhDk/Screen-Shot-2021-01-17-at-19-35-37.png)

Usually the Default Database is postgres, Username is like your computer name (in this case my computer name is : yosioliver) Then click Test Connection, if your fill the information correctly, pop up will appear like the image below : 

![Postgre](https://i.ibb.co/6B15XRN/Screen-Shot-2021-01-15-at-15-28-20.png)

Next step is Creating New Role (in this case my role username is purchasingsysusr, my password is PurchasingSys1234!@#$), please see image below for detail : 

![Postgre](https://i.ibb.co/G9LNM5r/Screen-Shot-2021-01-17-at-19-47-29.png)

After Creating New Role, then you need to create new Database (in this case my database name. : purchasingsysdb), set Owner for purchasingsysdb To purchasingsysusr.
Please see image below for detail : 

![Postgre](https://i.ibb.co/Prz4CLf/Screen-Shot-2021-01-17-at-19-47-08.png)

For Backend API / REST Api : 
  - .Net Core Framework Version 3.1
  - You can install here : [Download .Net Core SDK](https://dotnet.microsoft.com/download) - Please choose version : 3.1 for the compability with this Project (Because this Project built with .Net Core Version 3.1)


After successfully installing .Net Core SDK, type the command below on your terminal/console :

```sh
$ dotnet --version
```

After that, if .Net Core SDK installed successfully, you will prompted as below on your terminal/console :

```sh
$ 3.1.0
```

Markdown is a lightweight markup language based on the formatting conventions that people naturally use in email.  As [John Gruber] writes on the [Markdown site][df1]

> The overriding design goal for Markdown's
> formatting syntax is to make it as readable
> as possible. The idea is that a
> Markdown-formatted document should be
> publishable as-is, as plain text, without
> looking like it's been marked up with tags
> or formatting instructions.

This text you see here is *actually* written in Markdown! To get a feel for Markdown's syntax, type some text into the left window and watch the results in the right.

### Tech

Dillinger uses a number of open source projects to work properly:

* [AngularJS] - HTML enhanced for web apps!
* [Ace Editor] - awesome web-based text editor
* [markdown-it] - Markdown parser done right. Fast and easy to extend.
* [Twitter Bootstrap] - great UI boilerplate for modern web apps
* [node.js] - evented I/O for the backend
* [Express] - fast node.js network app framework [@tjholowaychuk]
* [Gulp] - the streaming build system
* [Breakdance](https://breakdance.github.io/breakdance/) - HTML to Markdown converter
* [jQuery] - duh

And of course Dillinger itself is open source with a [public repository][dill]
 on GitHub.

### Installation

Dillinger requires [Node.js](https://nodejs.org/) v4+ to run.

Install the dependencies and devDependencies and start the server.

```sh
$ cd dillinger
$ npm install -d
$ node app
```

For production environments...

```sh
$ npm install --production
$ NODE_ENV=production node app
```

### Plugins

Dillinger is currently extended with the following plugins. Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |


### Development

Want to contribute? Great!

Dillinger uses Gulp + Webpack for fast developing.
Make a change in your file and instantaneously see your updates!

Open your favorite Terminal and run these commands.

First Tab:
```sh
$ node app
```

Second Tab:
```sh
$ gulp watch
```

(optional) Third:
```sh
$ karma test
```
#### Building for source
For production release:
```sh
$ gulp build --prod
```
Generating pre-built zip archives for distribution:
```sh
$ gulp build dist --prod
```
### Docker
Dillinger is very easy to install and deploy in a Docker container.

By default, the Docker will expose port 8080, so change this within the Dockerfile if necessary. When ready, simply use the Dockerfile to build the image.

```sh
cd dillinger
docker build -t joemccann/dillinger:${package.json.version} .
```
This will create the dillinger image and pull in the necessary dependencies. Be sure to swap out `${package.json.version}` with the actual version of Dillinger.

Once done, run the Docker image and map the port to whatever you wish on your host. In this example, we simply map port 8000 of the host to port 8080 of the Docker (or whatever port was exposed in the Dockerfile):

```sh
docker run -d -p 8000:8080 --restart="always" <youruser>/dillinger:${package.json.version}
```

Verify the deployment by navigating to your server address in your preferred browser.

```sh
127.0.0.1:8000
```

#### Kubernetes + Google Cloud

See [KUBERNETES.md](https://github.com/joemccann/dillinger/blob/master/KUBERNETES.md)


### Todos

 - Write MORE Tests
 - Add Night Mode

License
----

MIT


**Free Software, Hell Yeah!**
