# Emojilang

![Discord_JF406z5zxL](https://user-images.githubusercontent.com/58154576/170095921-3d5528b3-9732-4d0b-b566-1e90332d3992.png)

Based on a meme a friend sent on Discord, this is a (kinda?) fake programming language based on Python, using its syntax. Specifically this includes a C# Windows Forms program that serves as a very basic (currently) pseudo-IDE for the language, featuring the ability to save files and run them within the program. 

The main feature of this "language" is that keywords/commands are represented using emojis! See the key below.

Technically, you can execute pure python from this program, but that's not the main purpose of this of course.

**TIP:** You can use (Windows Key)+: to open an emoji menu. Type in the name of an emoji and click on one on the menu to append it to your cursor.

## Notes
You'll need to provide your python.exe path in the program currently, under the 'pythonDirectory' variable, for the program to work. (e.g. mine is C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\Python37_64\\python.exe) I plan on implementing a better way of getting the user's python directory at a later point.

## Key
🏁 = 'def'

🖨 = 'print'

🤔 = 'if'

😕 = 'elif'

😔 = 'else'

✔ = '=' (use double ✔ for ==)

❌ = 'not'

↩ = 'return'

🙂 = 'True'

😢 = 'False'

▶ = '>'

◀ = '<'

The clock emojis are used for numbers from 1 to 9, with 12 o'clock representing 0 instead. 10/11 o'clock are excluded. Can be combined to form more complex numbers. E.g. 🕐🕒🕛 = 130

## Examples
![Emojilang_IDE_haK8qqsIaI](https://user-images.githubusercontent.com/58154576/170095943-044dabd0-f04d-4ca9-8bd4-0ea8173b63c4.png)

![Emojilang_IDE_6TqoswtLZf](https://user-images.githubusercontent.com/58154576/170095950-4855629c-b99d-487d-9346-fc39a2b8f738.png)

![Emojilang_IDE_STWQh6lZks](https://user-images.githubusercontent.com/58154576/170095959-06a37655-c3db-46f0-b2b4-f200942289c0.png)

## To do
- [ ] better way of getting user's python.exe path
- [ ] later load in emojilang files, instantly execute if already saved
- [ ] on-screen emoji keyboard?
- [ ] favicon when i'm not lazy

## Issues
- 'input()' doesn't work, will cause the program to hang. Probably won't be fixed
- Save As prompt always appears. To be fixed in #1 of the To Do list.

## What I learnt from this
- How to execute programs via the shell programatically