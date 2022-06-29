# Angular.Examples.MonoRepo
These examples use a [Nx Workspace](https://nx.dev/).  The command to run each example is below.

## Relationships between projects
Run this command ```nx graph``` in the client directory ([see also](https://nx.dev/using-nx/nx-cli#understanding-the-codebase)).

# Projects
In the Client folder, run this command:
- Dark Mode - ```nx run dark-mode:serve:development --watch```  or ```nx serve dark-mode```
- Akita Example ```nx run akita-example:serve:development --watch```  or ```nx serve akita-example```

# Modules added outside the defaults that come with NxWorkspace
- @datorama/akita
  - akita-example
- @angular/material  
  - akita-example
  
Install packages like you would in any normal Angular application.
npm install @datorama/akita

# Create new projects
---
I had to execute the two commands listed [here](https://nx.dev/packages/angular#setting-up-the-angular-plugin) and [here](https://nx.dev/packages/angular#generating-a-library) in the project folder (the one where the package.json and angular.json live):
1. ```npm install -D @nrwl/angular```
2. ```nx g @nrwl/angular:app appName```

Afterwards, I changed directories into the ```apps``` and then ```appName``` and finally ran this command ```nx serve appName```.
```npm install -D @nrwl/angular```

