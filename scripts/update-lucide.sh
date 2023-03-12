#!/bin/sh
git config user.name "lucide-blazor-actions"
git config user.email "<>"

CURRENT=$(git rev-parse HEAD:lucide)
LATEST=$(git ls-remote --quiet https://github.com/lucide-icons/lucide.git HEAD | grep -o '^\S*')

echo "current version: " $CURRENT
echo "latest version: " $LATEST

if [ "$CURRENT" != "$LATEST" ]; then
    echo "updating lucide to latest version."
    git submodule update
    git add ../lucide
    echo $(git status)
    git commit -m "Updating lucide to $LATEST"
    git push origin main
    echo "updated lucide."
else
    echo "lucide is already up to date."
fi