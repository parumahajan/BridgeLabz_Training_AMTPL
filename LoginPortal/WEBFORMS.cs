/*
--------------------------------------------------------
** WEB FORMS **
--------------------------------------------------------
- It is a Web Application Framework under ASP.NET, that allows the developers to build Dynamic, Event-Driven web applications using C#.

- Thus, it makes applications in a way, that it feels very similar to Windows Forms (i.e. desktop apps).

- Follows Event-based architecture.
--------------------------------------------------------
WHAT DOES IT DO ? (ABSTRACTS COMPLEXITIES)
--------------------------------------------------------
- It Abstracts the Complexities of HTML, HTTP, and JavaScript, letting developers work with server-side controls and events.

By Abstracting the Complexities, it means:

- Web Forms hides the low-level web details (like HTML rendering, HTTP requests, JavaScript) from the developer, and provides simpler, higher-level C# constructs instead.

# Here, C# constructs are the Built-In Language elements, structures, and features of C# that we use to write logic.
--------------------------------------------------------
WHAT EXACTLY HAPPENS IN WEB-FORMS ?
--------------------------------------------------------
In Web Forms, using C# code, we can make the interface within the web, through text boxes, buttons, events etc.

While, we construct the backend logic for it, using the ASP.NET.
--------------------------------------------------------
WHY IS IT USED ?
--------------------------------------------------------
- To do web dev using C# and .NET.

- To hide low-level web concepts like HTTP requests, and Stateless nature of the web.

- To provide rapid application development (RAD).

# Stateless nature of the web means:

Each HTTP request is independent, and the server does NOT remember anything about previous requests by default.
--------------------------------------------------------
WHERE ARE WEB FORMS USED ?
--------------------------------------------------------
- Legacy enterprise applications
- Government / banking systems
- Older ERP / CRM systems
--------------------------------------------------------
✅ Advantages of Web Forms
--------------------------------------------------------
✔ Easy for beginners
✔ Rapid development
✔ Event-driven model
✔ Less HTML/JS knowledge needed
✔ Strong integration with C# and .NET
--------------------------------------------------------
❌ Disadvantages of Web Forms
--------------------------------------------------------
❌ Heavy ViewState (performance hit)
❌ Poor control over generated HTML
❌ Not SEO-friendly by default
❌ Hard to unit test
❌ Not suitable for modern Single page application apps
❌ Considered obsolete for new development
--------------------------------------------------------
VIEWSTATE
--------------------------------------------------------
- ViewState is a state management mechanism in ASP.NET Web Forms that is used to remember the values of server-side controls between postbacks.

- It maintains the state between page reloads.

# Heavy ViewState (performance hit)
- Web Forms stores a large amount of page data and control data in ViewState, which increases page size and slows down performance.
--------------------------------------------------------
KEY-FEATURES:
--------------------------------------------------------
1) Server-side controls

- Server-side controls are UI elements (buttons, textboxes, grids, etc.) which run on the server, and are processed by ASP.NET.

- It has a rich-control set.

- They are written in ".aspx pages", and are marked withc runat="server". 

.aspx : "Active Server Pages Extended"
Files with these extension are basically aspx pages (HTML + Server side code (in C#) )n
--------------------------------------------------------
2) POSTBACK
- The browser sends the same page back to the server for processing the events.

It usually occurs when:

- A button is clicked
- A dropdown selection changes
- A form is submitted
--------------------------------------------------------
 




 */