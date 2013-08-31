Feature: Read9x9SudokuFromXml
	In order create sudoku's
	As a sudoku manager
	I want to load a sudoku from an xml file

@mytag
Scenario: Load a 9x9 matrix sudoku with values between 1 and 9 from xml
	Given I have a one star nine by nine sudoku with values between one and nine in xml format
	When I load the xml
	Then the result should be the one star sudoku in memory
