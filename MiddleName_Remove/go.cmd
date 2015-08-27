xcopy src ..\src /S /Y

cd ..

git add --all

git commit -m "Removing Middle name"

git push

sqlcmd -S peopletracker.database.windows.net -U dbrown -P P2ssw0rd -N -d PeopleTrackerDB-dev "delete from people where FirstName <> 'Dev' OR LastName <> 'User';"
sqlcmd -S peopletracker.database.windows.net -U dbrown -P P2ssw0rd -N -d PeopleTrackerDB-qa "delete from people where FirstName <> 'QA' OR LastName <> 'User';"
sqlcmd -S peopletracker.database.windows.net -U dbrown -P P2ssw0rd -N -d PeopleTrackerDB "delete from people where FirstName <> 'Prod' OR LastName <> 'User';"