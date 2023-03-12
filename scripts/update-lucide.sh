#!/bin/sh
git config user.name "lucide-blazor-actions"
git config user.email "<>"

CURRENT=$(git rev-parse HEAD:lucide)
LATEST=$(git ls-remote --quiet https://github.com/lucide-icons/lucide.git HEAD | grep -o '^\S*')

echo "current version: " $CURRENT
echo "latest version: " $LATEST

if [ "$CURRENT" != "$LATEST" ]; then
    echo "Updating to latest version."

    git submodule update --init --recursive --remote

    STATUS=$(git status)  
    
    if [ "$STATUS" != *"modified: ../lucide"* ]; then
        echo "No updates required."
        exit 0
    fi

    BRANCH=lucide-update/$LATEST

    git checkout -b $BRANCH
    git add ../lucide
    git commit -m "Updating lucide to $LATEST"
    git push origin $BRANCH

    echo "Update completed."
else
    echo "No updates required."
fi