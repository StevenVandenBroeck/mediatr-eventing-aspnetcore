# Mediatr eventing library

Eventing library using Mediatr.

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->



<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Startup

Add the library to a project, add the following in the project.json :

```json
"Quixilver.Mediatr": "1.1.0"
```  

Register the eventing services and event handlers in the **ConfigureServices** method of the **Startup** class :

```csharp
service.AddEventing(options => {
    options.RegisterEventHandler<AnEvent, MyEventHandler>();
    options.RegisterAsyncEventHandler<AnotherEvent, MyAsyncEventHandler>  ();
});
```  

## Publishing Events

You can publish synchronous and asynchronous events with the **IEventPublisher**. All events must inherit from the **AppEvent** class.

### IEventPublisher.Publish

Publishes an event to all event handlers that are attached for the given type of event. The method returns when all event handlers have finished handling the event.

```csharp
var myEvent = new MyEvent() { /* initialize some properties*/ } ;
eventPublisher.Publish(myEvent);
// code below the above statement will execute when all subcribed event handler have handled the event
```  

### IEventPublisher.PublishAsync

With the PublishAsync method, the event handlers are called asynchronously and the method returns immediately. 

```csharp
var myEvent = new MyEvent() { /* initialize some properties*/ } ;
eventPublisher.PublishAsync(myEvent);
// code below the above statement will immediately execute
```  

If you want to wait until all event handlers have handled the event, you can use the **await** statement.

```csharp
var myEvent = new MyEvent() { /* initialize some properties*/ } ;
await eventPublisher.PublishAsync(myEvent);
```  

## Event Handlers 


## Exception handler for async publish



