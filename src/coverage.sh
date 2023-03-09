#!/bin/bash
dotnet test Lucide.Blazor.sln --collect:"XPlat Code Coverage"
reportgenerator -reports:./**/coverage.cobertura.xml -targetdir:./coverage -reporttypes:Cobertura
reportgenerator -reports:./coverage/Cobertura.xml -targetdir:./coverage/report -reporttypes:HtmlInline
find ../ -type d -name "TestResults" -exec rm -rf {} \;
