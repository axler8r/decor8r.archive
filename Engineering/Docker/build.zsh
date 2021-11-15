#!/usr/bin/env zsh

PRODUCT="Unknown"
MAJOR=0
MINOR=0
PATCH=0

if [[ ! -f ./TAG ]] {
    printf "%s\n" "Missing TAG file, using defaults"
} else {
    PRODUCT=$(cat TAG | grep PRODUCT | sed -e 's/PRODUCT=//')
    MAJOR=$(cat TAG | grep MAJOR | sed -e 's/MAJOR=//')
    MINOR=$(cat TAG | grep MINOR | sed -e 's/MINOR=//')
    PATCH=$(cat TAG | grep PATCH | sed -e 's/PATCH=//')
}

[[ "${PATCH}" == "auto" ]] && PATCH=$(date +%H%M%S)
TAG="${PRODUCT}:${MAJOR}.${MINOR}.${PATCH}"
if [[ -x $(which docker) ]] {
	docker build --tag "${TAG}" .
} else {
    printf "%s\n" "Docker not installed"
}

