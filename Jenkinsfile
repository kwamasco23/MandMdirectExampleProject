pipeline {
    agent any
    
    environment {
        CI = 'true'
    }
    
    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/kwamasco23/MandMdirectExampleProject.git'
            }
        }
        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release --no-restore'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test --configuration Release --no-build --logger "trx;LogFileName=test-results.trx"'
            }
        }
    }
    
    post {
        always {
            junit '**/TestResults/*.trx'
        }
        success {
            echo '✅ CI pipeline succeeded'
        }
        failure {
            echo '❌ CI pipeline failed'
        }
    }
}