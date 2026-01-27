pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/kwamasco23/MandMdirectExampleProject.git'
            }
        }

        stage('Restore') {
    steps {
        sh 'dotnet restore'
    }
}


        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                bat '''
                dotnet test ^
                  --no-build ^
                  --configuration Release ^
                  --logger "nunit;LogFilePath=TestResults\\nunit-results.xml"
                '''
            }
            post {
                always {
                    junit 'TestResults/**/*.xml'
                }
            }
        }
    }

    post {
        success {
            echo '✅ CI pipeline completed successfully'
        }
        failure {
            echo '❌ CI pipeline failed'
        }
    }
}
