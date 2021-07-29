Azure Function running on Kubernetes with KEDA
	Follow  following link to install KEDA and Azure Function in your kubernetes cluster
	#Link - https://microsoft.github.io/AzureTipsAndTricks/blog/tip278.html
	
	Step 1: Build Function Image
	docker build -t imagerepositoryusername/imagename .
	
	Step 2: Generate Deployment yaml File
	func kubernetes deploy --name functionappname --image-name "imagerepositoryusername/imagename" --dry-run > deploy.yml
	
	Step 3: Modify Azure Connection
	Go to kind: ScaledObject section in deploy.yml file
	Modify connectionFromEnv: '' to connectionFromEnv: AzureWebJobsStorage 
	Run kubectl apply -f deploy.yml