"ThirdPartyReferences\nunit\nunit-console.exe" /labels /out=TestResult.txt /xml=TestResult.xml /framework=net-4.0 Sudoku.Specs\bin\Debug\Sudoku.Specs.dll
 
"packages\SpecFlow.1.9.0\tools\specflow.exe" nunitexecutionreport Sudoku.Specs\Sudoku.Specs.csproj
 
IF NOT EXIST TestResult.xml GOTO FAIL
IF NOT EXIST TestResult.html GOTO FAIL
EXIT
 
:FAIL
echo ##teamcity[buildStatus status='FAILURE']
EXIT /B 1