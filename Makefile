dev:
	@echo "Running server on development mode"
	# cd to backend directory and run the server
	cd backend && go run main.go

prod:
	@echo "Running server on production mode"
	# cd to backend directory and run the server
	./deploy.sh

.PHONEY:
	dev prod
