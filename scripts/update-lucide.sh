#!/bin/sh
git config user.name "lucide-blazor-actions"
git config user.email "<>"

echo $PWD
CURRENT=$(cd ../lucide && echo $PWD && git rev-parse HEAD)
LATEST=$(cd ../lucide && echo $PWD && git ls-remote --quiet https://github.com/lucide-icons/lucide.git HEAD | grep -o '^\S*')

echo "current version: " + $CURRENT
echo "latest version: " + $LATEST

if [ "$CURRENT" != "$LATEST" ]; then
    echo "updating lucide to latest version."
    git submodule update
    git add lucide/
    git commit -m "Updating lucide to $LATEST"
    git push origin main
    echo "updated lucide."
else
    echo "lucide is already up to date."
fi