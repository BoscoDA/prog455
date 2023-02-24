# Week 5 Notes

## What is Authentication

- Authentication is the process of identifying if a user has accesss to a system
- Does not control rights or roles
- Can have multiple methods to implement:
	- Single Factor: Traditional username and password
	- Multi Factor: (MFA/2FA/3FA): A randomly generated code is used in addition to the username and password
	- Single Sign On (SSO): A token is exchanged between the system and a recognized idenity provide such as google account or appl id.
## What is Authorization

- Authorization is the process of identifying if a user who already obtained access ahs priviliges to requested content
- It controls rights and roles
- Role based method is the most common. Predetermined roles are given set of rules, and users are added or assigned roles. 
	- A user can ahve view only rights, while a manager can have edit, and a superuser can delete.
	- Hierarchy or distributed based
- Key Based methods where few keys are given different rights, and the user must input the correct key to execute certain actions.
	- This is most used in APIs

## Password Hashing

- Usernames and passowrds are stored in a data persisting resource such as a database
- Passwords shuld NEVER be stored as plain text
- To avoid storing text, we encrypt the passwords to create hashes
- There are many different types of hashing, we should at minimum use SHA256
- Once you hash a password, you can not retrieve the original password
- When a user logins, we hash their input and compare it to the hash saved in the database

## Hashing Algorithms

- There are not many hashing algorithms around, they range from legacy MD5 to PBKDF2
- As of today, the minimum recommended methods is SHA256
- Older methods such as MD5 can cause collision and reverse lookup is possible
- Collision is when two passwords produce the same hash
- A Salt is a number that is used to fudge the encrption, which adds another level of complexity to the hash
	- Salt: a random number 
		- Can be the number of times you shift the bits, the number of times you hash the password
	- Amazon each user gets their own salt based on a number of ticks
	- There is also Pepper now
- Rehashing is the iterative process or hashing the hash to increase security

