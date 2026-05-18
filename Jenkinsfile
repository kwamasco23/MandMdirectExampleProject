pipeline {
    agent {
        docker {
            image 'selenium/standalone-chrome:latest'
            args '--shm-size=2g'
        }
    }

    environment {
        CI = 'true'
    }

    stages {
        stage('Checkout') {
            steps { checkout scm }
        }

        stage('Restore') {
            steps { sh 'dotnet restore' }
        }

        stage('Build') {
            steps { sh 'dotnet build --configuration Release' }
        }

        stage('Test') {
            steps { sh 'dotnet test --configuration Release' }
        }
    }
}