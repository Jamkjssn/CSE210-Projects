Goal Importance = gi
Goal Difficulty = gd


(gi+gd) = weight

Equation:
points = -165 + 1.155^(x+39)

gi and gd are given on a scale of 1-10 


we want it split into big goal and 2-3 little goals that will help the person work towards their goal

include a part to help teach how to set goals (SMART)

Record when it is that they complete goals or make progress towards completing them.
	- Reward them with points when they log in multiple consecutive days
		- Streak saver whenever they login for a whole week and complete at least one goal
	- Rather than yes or no, maybe add ways for goal recordings to be partial credit?

Levels
	- Rather than levels lets go with Ranks
	- Each rank has a title, this can be split up into tiers ("Adjective" "Title")
	- Keep these mostly linear so that you can just reset exp but change title to the next one in the list
	- Upon Title Rank-Ups they earn a streak saver

Profiles can be saved in a profile folder. The person will "Login" or "Create Profile" when they begin each time. Each time they login their streak counter will update. Whenever they report a goal their streak counter will update in the background. 

Class for Profile
properties:
	- Name
	- Rank adjective
	- Rank title
	- Experience
	- Goals completed
	- Goals Set
	- Goal Completion ratio
	- Current login streak
Methods:
	- CalculateCompletionRatio
	- AddGoalCompleted
	- AddGoalSet
	- CheckLoginStreak
	- Rankup

Class for Goals
// This is a base class and wont actually be used on its own
Properties:
	- Type
	- Name
	- Description
Methods:
	- 

Menu section:
	- Create Goal
		- Create Simple Goal
		- Create Checklist Goal
		- Create Eternal Goal
	- View Goals
	- Report Goal Progress
	- View Profile 
	- Help
		- How to set goals
		- Streak Savers
		- Report a problem
	- Settings
		- Edit Profile
		- Toggle Autosave
		- Save Profile and Goals
	- Quit

Help section:
	- How to set goals
	- Streak Savers
	- Report a problem


//At the bottom here inform them that things can be edited from settings

So, we're going to have goals, there are several different types of goals. There are goals that are finished quickly, these are completion goals. On the other hand there are Goals that are progressive goals. These have land marks which need to be completed. Finally are repetative goals. These goals need to be done a certain number of times or need to be done continuously. Regardless of type every goal is going to have a name, type, description, and completion status. They'll also have methods for marking them complete, and awarding points. 
Simple goals have a completion status, and are marked as complete or incomplete. 
Checklist Goals have multiple parts and progress amounts.
Eternal Goals need to be completed multiple times/daily. 




walkthrough:

User enters into the program. They are asked if they already have a profile or would like to create one. Either way a username is asked for. They are then taken to the menu, when they try to create a goal they select the type of goal, and then are given the option to name it. //This is where the goal is initially created.// After this they input the goal, how important it is to them, and how difficult it is. For some classes they will also add in other details but these are the basic parts