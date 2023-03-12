#!/bin/sh
git config user.name "lucide-blazor-actions"
git config user.email "<>"

CURRENT=$(git rev-parse HEAD:lucide)
LATEST=$(git ls-remote --quiet https://github.com/lucide-icons/lucide.git HEAD | grep -o '^\S*')

echo "current version: " $CURRENT
echo "latest version: " $LATEST

if [ "$CURRENT" != "$LATEST" ]; then
    echo "1 updating lucide to latest version."
    git submodule update --init --recursive --remote
    echo "2 " $(git status)  
    git add ../lucide
    echo "3 " $(git status)
    git commit -m "Updating lucide to $LATEST"
    echo "4 " $(git status)
    git push origin main
    echo "updated lucide."
else
    echo "lucide is already up to date."
fi