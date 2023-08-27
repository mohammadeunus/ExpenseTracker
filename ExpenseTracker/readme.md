##take away from the project
- use DTO to encapsulate all action from user.
- never commit any code with errors in the master branch.
- don't expose code to user through return type. 
	- badPractice: return badrequest($"user id {userId} is not available.")
	- right approach: return badrequest("this user is not available.")