# Emojilang

Based on a meme a friend sent on Discord, this is a (kinda?) fake programming language based on Python, using its syntax. Specifically this includes a C# Windows Forms program that serves as a very basic (currently) pseudo-IDE for the language, featuring the ability to save files and run them within the program. 

The main feature of this "language" is that keywords/commands are represented using emojis! See the key below.

Technically, you can execute pure python from this program, but that's not the main purpose of this of course.

**TIP:** You can use (Windows Key)+: to open an emoji menu. Type in the name of an emoji and click on one on the menu to append it to your cursor.

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

## To do
- [ ] later load in emojilang files, instantly execute if already saved
- [ ] on-screen emoji keyboard?
- [ ] favicon when i'm not lazy

## Issues
- 'input()' doesn't work, will cause the program to hang. Probably won't be fixed
- Save As prompt always appears. To be fixed in #1 of the To Do list.

## What I learnt from this
- How to execute programs via the shell programatically

🏁 main():
	print('hello world')

main()