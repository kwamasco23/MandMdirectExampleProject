pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                // Pull code from GitHub
                git branch: 'main', url: 'https://github.com/kwamasco23/MandMdirectExampleProject.git'
            }
        }

        stage('Restore') {
            steps {
                // Restore NuGet packages
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                // Build the solution in Release mode
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                // Run tests without rebuilding
                bat 'dotnet test --no-build --verbosity normal'
            }
        }
    }

    post {
        always {
            // Optional: Archive test results or artifacts
            archiveArtifacts artifacts: '**/bin/Release/**', allowEmptyArchive: true
            junit '**/TestResults/*.xml'
        }

        success {
            echo 'Build and tests succeeded!'
        }

        failure {
            echo 'Build or tests failed. Check logs!'
        }
    }
}
