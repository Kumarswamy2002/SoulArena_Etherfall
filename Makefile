.PHONY: all build run test lint docker clean

all: build test

build:
	@echo "Building Soul Arena: Etherfall Game & Backend..."
	python -m pip install -r Backend/requirements.txt

run:
	@echo "Starting FastAPI Backend Server..."
	python main.py

test:
	@echo "Running Automated Pytest Test Suite..."
	python -m pytest Backend/tests/ -v

docker:
	@echo "Launching Docker Compose Services..."
	cd Docker && docker compose up --build -d

clean:
	@echo "Cleaning cache files..."
	find . -type d -name "__pycache__" -exec rm -rf {} +
