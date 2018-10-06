# netcore-assignment

This is a starting repo all assignments for the class should be completed in. It contains the minimum requirements for an assignment repository:
* .gitignore - prevents tracking of files that do not need tracking
* README.md - explains what the repository is for

## Getting setup
1. Make a new directory under your documents folder: `mkdir ~\Documents\ACA`
2. Clone [netcore-workbook](https://github.com/AustinCodingAcademy/netcore-workbook): `git clone https://github.com/AustinCodingAcademy/netcore-workbook.git ~\Documents\ACA`
3. Clone [netcore-assignment](https://github.com/daniefer/netcore-assignments): `git clone https://github.com/daniefer/netcore-assignments.git ~\Documents\ACA`

## How to setup for a new assignment
For each assingment:
1. Create a new folder for that lesson if one does not aleady exist. For example, for Lesson 5.5 create a new directory in the root of the respositry called `Lesson05.5`
2. In this new directory, do one of the following:
   * For Pre-Work assingments, create a new directory under that lesson's folder called `prework`. Then copy the [netcore-workbook](https://github.com/AustinCodingAcademy/netcore-workbook) lesson's `StartOfLesson` folder contents (not the folder itself, but everything it contains) into that lesson's folder. Using the example above, you would copy [netcore-workbook/Lesson05.5/StartOfLesson](https://github.com/AustinCodingAcademy/netcore-workbook/tree/master/Lesson05.5/StartOfLesson) contents into the `Lesson05.5/prework` folder. 
   * For Homework assignments, create a new directory under that lesson's folder called `homework`. Then copy the [netcore-workbook](https://github.com/AustinCodingAcademy/netcore-workbook) lesson's `EndOfLesson` folder contents (not the folder itself, but everything it contains) into that lesson's folder. Using the example above, you would copy [netcore-workbook/Lesson05.5/EndOfLesson](https://github.com/AustinCodingAcademy/netcore-workbook/tree/master/Lesson05.5/EndOfLesson) contents into the `Lesson05.5/homework` folder.
3. Commit these additions to the master branch.
4. Create a new branch for the pre-work or homework assignment. Follow a naming convention of somekind such as `lesson{number}-{prework|homework}` where `{number}` is replaced with the chapter/lesson number and replacing `{prework|homework}` with either `prework` or `homework`. Using the example in step 1, I would name the branch either `lesson05.5-prework` for pre-works or `lesson05.5-homework` for homeworks.
5. Do all work for the assignment on this branch. Submit the assignment as a pull request back into your forked master and provided the link to the pull request in Campus Manager.

## Typical workflow before starting an assignment:
#### PowerShell
```powershell
/> cd ~\Documents\ACA\netcore-assignments
/> mkdir Lesson02
/> cd Lesson02
/> mkdir prework
/> cd prework
/> cp ..\..\..\netcore-workbook\Lesson02\StartOfLesson\* -Recurse -Destination .
```
