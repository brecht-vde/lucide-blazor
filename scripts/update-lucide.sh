#!/bin/sh
cd ../lucide

CURRENT=$(git rev-parse HEAD)
LATEST=$(git ls-remote --quiet https://github.com/lucide-icons/lucide.git HEAD | grep -o '^\S*')

echo $LATEST
echo $CURRENT

if [ "$CURRENT" != "$LATEST" ]; then
     echo "updating lucide."
    git submodule update
    cd ../
    git add lucide/
    git commit -m "Updating lucide to $LATEST"
    git push origin main
    echo "updated lucide."
else
    echo "lucide is already up to date."
fi