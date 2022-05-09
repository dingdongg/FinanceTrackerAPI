# FinanceTrackerAPI

`FinanceTrackerAPI` is an API that logs the various transactions you make throughout your day 💸✅

Using this API, users can log their transactions, edit/view their previous transactions, and delete them if needed using the 6 API endpoints provided.

The API adheres to REST principles and is built on top of the MVC architecture. Dependency injections and the repository pattern has decoupled 
the internal components of this API, increasing scalability and flexibility in the face of future design changes. In addition, data transfer objects (DTOs)
provide client-to-server decoupling by separating data presentation to the clients from the server-side, effectively making this API a blackbox.

This is the back-end component of a web application I am planning on designing 🤗

## Issues
* `FinanceTrackerAPI` does not support asynchronous operations; this will be updated in the coming days
* Error messages returned by data annotations are incorrect; this will be updated in the coming days
* Generally, since transactions can be either an expense or an asset, the Transaction class may be updated to reflect this bit of info
