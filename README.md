# HandlerFactory
A windsor factory library to choose and resolve a handler out of many handlers which share the same common interface.
The handler objects could not be created yet at the time of the build or the time of the run,
it can added as a package ID and URL in the configuration(to be resolved on the deployment time)
or could be added through an api call to the host service (to be resolved on the run time)
