/*
--------------------------------------------------
** EVENTS **
--------------------------------------------------
-> It is a mechanism which is used to allow a class to notify other classes, when something happens.

-> The classes which inform are called "Publishers", and the ones which receive information are called "Subscribers".

-> Events are built on top of delegates.

-> They follow the OBSERVER-PATTERN (Pub-Sub model)

-> Event is nothing but a message, which is sent by an object to all the other subscribed objects, stating that an action has occured.
--------------------------------------------------
ANALOGY:

a) When a button is clicked, multiple listeners respond to it. That button can be any physical button on a remote, life, or computer mouse.

It is termed as a "Publisher".
 
-> The button’s only job is to: Detect A Click.

That click is termed as an "Event".

It does not know:
- What will happen after clicking
- Who will react
- How many actions will occur
 
1) Button.Click
-> The button has been clicked.

2) Click?.Invoke();
-> The publisher just tells that, it has been clicked.

b) Now, different systems will listen to the button, in order to perform some action. 

We'll call them "Subscribers".

-> Each listener has registered themself earlier.

-> Through the event which is raised by publisher, the every subscriber gets notified about it.

3) button.Click += TurnOnLight; 
4) button.Click += StartTimer;

* Each listener reacts independently.

"The button follows the Principle of "LOOSE-COUPLING".

WHAT CAN WE DO ?

Without touching the button code, we can:
- Add new listeners
- Remove existing listeners
- Change behavior

Changing behaviour means:

-> "Changing what happens after an event occurs, without changing the code that raised the event."


 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 */