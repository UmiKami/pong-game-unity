# App Summary

This project is just a recreation of the classic pong game where two players try to score 10 points to win. The ball must go past one of the players for it to score a point. 

# Reasoning

The whole purpose of this app is to start learning unity. I had already made the game in LUA with the Love2D library follwing the Harvard CS50G course. I decided to get ahead of the game and start learning unity now from scratch without looking at tutorials. This is my first project successfully completed in Unity without following a tutorial or following in tutorial hell.

After the completion of this App I will continue to follow the CS50G course to learn the fundamentals that I am 99% sure lack. 


# Challenges Experience During Developement
  1. State management. I am still not sure how to handle the state accross multiple scenes or in which scripts to put certain states. Should the counter be handle by the ball script or should it be handle by the ScoreManager script? Upfront it doesn't make sense the counter before the ball is fired, is handled by the ball, on the other side, it is a lot easier to set it up within the Ball's script than on a separate Script that would need to count down and fire the ball anyway.
  2. At first I struggled with passing data from one Scene (Level) to the other. After a few seconds of googlin, I found out I could make member variables static for them to persist accross the different Scenes. Honestly, this is a very basic OOP programming concept, I do not how it went over my head. Overthinking is definetely my worst enemy.


# Next Up

The next game I have in mind is the Snake game. this will be step up in complexity as there will be more failure points to be weary of. For example:
  - What happens if the head of the snake turns one way? I can't just change the direction of the rest of the body, I have to turn the body parts of the snake as they reach the turning point and I need to find a way to store the direction and coordinates of the turning point. The turning point also needs to be removed once the last body part goes through it.
  - What happens if there are multiple turning points? I guess I need to store them in array of some sort.
