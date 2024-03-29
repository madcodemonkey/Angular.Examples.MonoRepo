# Angular.Examples.MonoRepo
This is a mono-repo containing several Angular applications, but sharing one node modules folder.  For info about the mono-repo used in these examples see [Nx Workspace](https://nx.dev/).  The command to run each example is below in "Running a project" section.

## Running a project
In the client folder run the following command to install the necessary packages:
```npm install```

In the Client folder, run one of these commands:
- ag-grid-example
   - What: Demostrates basic usage of the of the [Ag Grid component](https://www.ag-grid.com/)
   - Requires server?  Yes, you'll also need to run the server project
   - Run it: ```nx run ag-grid-example:serve:development --watch```  or```nx serve ag-grid-example```
- akita-example 
   - What:  Demostrates using [Akita state management](https://opensource.salesforce.com/akita/docs/store)
   - Requires server?  Yes, you'll also need to run the server project
   - Run it: ```nx run akita-example:serve:development --watch```  or ```nx serve akita-example```
- dark-mode 
   - What: Demostrates switching between light and dark mode using [CSS variables](https://developer.mozilla.org/en-US/docs/Web/CSS/Using_CSS_custom_properties)
   - Requires server?  No
   - Run it: ```nx run dark-mode:serve:development --watch```  or ```nx serve dark-mode```
- simple-examples
   - What: Miscellanous examples that show different simplier concepts
   - Requires server?  Yes 
   - Run it: ```nx run simple-examples:serve:development --watch```  or ```nx serve simple-examples```
   
   
## Creating a new project
From the client directory, I had to execute the two commands listed [here](https://nx.dev/packages/angular#setting-up-the-angular-plugin) and [here](https://nx.dev/packages/angular#generating-a-library) in the main folder (the one where the package.json and angular.json live):
1. ```npm install -D @nrwl/angular```
2. ```nx g @nrwl/angular:app appName```

Afterwards, I changed directories into the ```apps``` and then ```appName``` and finally ran this command ```nx serve appName```.
```npm install -D @nrwl/angular```

## Relationships between projects
Run this command ```nx graph``` in the client directory ([see also](https://nx.dev/using-nx/nx-cli#understanding-the-codebase)).

## Modules installed 
Outside the defaults that come with NxWorkspace, I've installed these packages:
- @datorama/akita
  - CMD: npm install @datorama/akita
  - Used by: akita-example
- @angular/material  
  - CMD: npm install @angular/material  
  - Used by: akita-example
- ag-grid-community  (generic library for any JavaScript app) 
  - CMD: npm install --save ag-grid-community
  - Used by: ag-grid-example   
- ag-grid-angular    (specific code for Angular) 
  - CMD: npm install --save ag-grid-angular
  - Used by: ag-grid-example   

---  
# Errors
## Error 1: More than one version of Angular found
If you see this error
Workspace config file cannot be loaded: <your path here>\Angular.Examples.MonoRepo\Client\angular.json
Invalid format version detected - Expected:[ 1 ] Found: [ 2 ]


# Creating from scratch
create-nx-workspace yates --preset=angular

Run all the module installs again.

# Upgrading notes
Be sure to delete node_modules folder
Be sure to delete .angular directory

# Branching scheme
- Main branch: Angular 14 
- [Future] I will create a branch for older Angular code
