@echo off

xmldoc2md "%1%2.dll" --output "./Resources/Documentation/pages/docs/%2" --gitlab-wiki --back-button

echo "Press any key to continue..."
pause