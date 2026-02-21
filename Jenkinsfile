pipeline {
    agent {
        docker {
            image 'selenium/standalone-chrome:latest'
            args '-u root --shm-size=2g'
        }
    }

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
        CI = 'true'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test --configuration Release --logger "trx;LogFileName=test-results.trx"'
            }
        }
    }

    post {
        always {
            junit '**/TestResults/*.trx'
        }
        failure {
            echo '❌ CI pipeline failed'
        }
        success {
            echo '✅ All tests passed'
        }
    }
}