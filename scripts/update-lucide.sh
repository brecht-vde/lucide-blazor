#!/bin/bash
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
    UPDATED="modified:   ../lucide" 
    
    if [[ "$STATUS" != *"$UPDATED"* ]]; then
        echo "No updates required."
        exit 0
    fi

    BRANCH=lucide-update/$LATEST
    EXISTS=$(git ls-remote --heads https://github.com/brecht-vde/lucide-blazor.git $BRANCH)

    if [ ! -z "$EXISTS" ]; then
        echo "A branch already exists for this update."
        exit 0
    fi

    git checkout -b $BRANCH
    git add ../lucide
    git commit -m "Updating lucide to $LATEST"
    git push origin $BRANCH

    echo "BRANCH=$BRANCH" >> $GITHUB_OUTPUT

    echo "Update completed."
else
    echo "No updates required."
fi