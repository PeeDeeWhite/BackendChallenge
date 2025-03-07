#Backend Challenge

## Introduction
I choose to use an appsettings json file so I could easily load and modify the room and answers data.
I added the ability to limit which rooms where available from each room and at the start.
Each room can have any number of answers and an answer can optionally send you to specific room.
I added the exit as type of room which would enable multiple paths to the exit.

## Limitations
There is only error handling for the loading of the configuration file.
The use of Console for input and output means that is very difficult to write unit tests for the program. I would normally have abstracted out the input and writelines. See my [ColourSortSolver project](https://github.com/PeeDeeWhite/ColourSortSolver) where I use an IWriter interface.